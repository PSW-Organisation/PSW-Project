import { Component, OnInit } from "@angular/core";
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from "ngx-toastr";
import { Question } from "./question";
import { Survey } from "./survey";
import { SurveyService } from "./survey.service";

@Component({
    selector: 'app-survey',
    templateUrl: './survey.component.html',
    styleUrls: ['./survey.component.css'],
    providers: [NgbRatingConfig]
})
export class SurveyComponent implements OnInit {
    constructor(config: NgbRatingConfig, private service: SurveyService, private toastr: ToastrService) {
        config.max = 5;
    }
    answers: Array<number> = [];
    ngOnInit() {
        this.fillAnswers();
    }

    createSurvey() {
        this.service.createSurvey(this.createdSurvey()).subscribe(response => {
            if (response.status === 200) {
                this.showSuccess("SUCESS")
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

    createdSurvey(): Survey{
        let q: Question[] = []
        for (let index = 0; index < 15; index++) {
            q.push({ id: index + 1, value: this.answers[index], category: index > -1 && index < 5 ? 0 : index > 4 && index < 10 ? 1 : 2 })
        }
        let survey: Survey = {
            patientId: "imbiamba",
            submissionDate: new Date((Date.now())),
            visitId: 1,
            questions: q
        }
        return survey;
    }
}