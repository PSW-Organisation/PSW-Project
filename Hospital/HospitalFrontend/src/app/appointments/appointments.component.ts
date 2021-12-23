import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { ProfileService } from '../profile/profile.service';
import { Visit } from '../profile/visit';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  visits: Visit[] = [];

  username: string = '';

  constructor(private route: ActivatedRoute, private profileService: ProfileService,
    private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['username']) {
        this.username = params['username'];
        this.profileService.getVisits(params['username']).subscribe({
          next: response => {
            this.visits = response
            /*this.visits = this.visits.flatMap(v => {
               doctorFullName : v.doctorFullName,
               
            } )*/
          }
        })
      }
    });
  }

  getVisitStatus(visit: Visit): string {
    if (visit.isCanceled) return "Canceled";
    else if (moment(visit.startTime).isAfter(moment()))
      return "Forthcoming";
    return "Completed";
  }

  openSurvey(id: number): void{
    this.router.navigate(["/survey"], {queryParams: {visitId: id}});
  }

  cancelAppointment(visit: Visit): void {
    this.profileService.cancelVisit(visit.id).subscribe({ 
      next: response => {
          visit.isCanceled = true;
          this.showSuccess('Successfully canceled appointment!');
      }, error: e => (this.showError('An error occured.'))
    })
  }

  isCompleted(visit: Visit): boolean {
    return moment(visit.startTime).isBefore(moment())
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }

}