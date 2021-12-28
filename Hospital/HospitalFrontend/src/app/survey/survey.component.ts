import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import * as moment from "moment";
import { ToastrService } from "ngx-toastr";
import { Question } from "./question";
import { Survey } from "./survey";
import { SurveyService } from "./survey.service";
import { Visit } from "../profile/visit";



@Component({
    selector: 'app-survey',
    templateUrl: './survey.component.html',
    styleUrls: ['./survey.component.css'],
    providers: [NgbRatingConfig]
})
export class SurveyComponent implements OnInit {
    constructor(config: NgbRatingConfig, private service: SurveyService, private toastr: ToastrService,
        private route: ActivatedRoute, private router: Router) {
        config.max = 5;
    }
    answers: Array<number> = [];
    visit: Visit = {
        id: 0,
        patientId: '',
        startTime: new Date(),
        endTime: new Date(),
        visitType: 0,
        doctorId: "",
        isReviewed: false,
        isCanceled: false,
        doctor: undefined
    };

    ngOnInit(): void {
        this.route.queryParams.subscribe(params => {
            if (params['visitId']) {
                this.service.getVisitById(params['visitId']).subscribe({
                    next: response => {
                        if (response.body.isReviewed || moment(response.body.startTime).isAfter(moment())) {
                            this.router.navigate(['/'])
                            this.showError('An error has occured.')
                        } 
                        else {
                            this.visit = response.body;
                        }
                    }, error: e => {
                        this.router.navigate(['/'])
                        this.showError('An error has occured.')
                    }
                })
            }
        });
        this.fillAnswers();
    }

    createSurvey() {
        this.service.createSurvey(this.createdSurvey()).subscribe(response => {
            if (response.status === 200) {
                this.service.reviewVisit(this.visit.id).subscribe({
                    next: response => {
                        this.showSuccess("SUCCESS")
                        this.router.navigate(['/appointments'])
                      }, error: e => (this.showError("FAILED"))
                })
            } else {
                this.showError("FAILED")
            }
        })
    }

    fillAnswers() {
        for (let index = 0; index < 15; index++) {
            this.answers[index] = 3;
        }
    }

    showSuccess(message: string) {
        this.toastr.success(message);
    }

    showError(message: string) {
        this.toastr.error(message);
    }

    createdSurvey(): Survey {
        let q: Question[] = []
        for (let index = 0; index < 15; index++) {
            q.push({ id: index + 1, value: this.answers[index], category: index > -1 && index < 5 ? 0 : index > 4 && index < 10 ? 1 : 2 })
        }
        let survey: Survey = {
            patientId: this.visit.patientId,
            submissionDate: new Date((Date.now())),
            visitId: this.visit.id,
            questions: q
        }
        return survey;
    }
}