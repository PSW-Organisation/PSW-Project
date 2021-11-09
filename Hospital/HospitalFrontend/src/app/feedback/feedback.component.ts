import { Component, OnInit } from '@angular/core';
import { FeedbackService } from './feedback.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AnimationOptions } from 'ngx-lottie';
import player from 'lottie-web';
import { Feedback } from './feedback';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { formatDate } from '@angular/common';


@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  text: string = '';
  feedbackForm = new FormGroup({
    text: new FormControl('')
  });
  feedbacks: any;

  constructor(private service: FeedbackService, private modalService: NgbModal,
    private toastr: ToastrService) { }

  options: AnimationOptions = {
    path: 'https://assets7.lottiefiles.com/packages/lf20_s1nooojy.json',
    loop: true,
    autoplay: false,
    name: 'feedbackGiven',
  };
  showAnimation = true;

  ngOnInit(): void {
    this.feedbackForm = new FormGroup({
      textControl: new FormControl(
        this.text, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(100)
      ]),
      anonymityControl: new FormControl(false),
      publishControl: new FormControl(false)
    });
  }

  sendFeedback(modal: any) {
    let feedback: Feedback = {
      patientUsername: 'imbiamba',
      submissionDate: new Date((Date.now())),
      text: this.feedbackForm.get("textControl")?.value,
      anonymous: this.feedbackForm.get("anonymityControl")?.value,
      publishAllowed: this.feedbackForm.get("publishControl")?.value,
      isPublished: false
    }

    this.service.createFeedback(feedback).subscribe({
      next: c => {
        console.log(c)
        if (c.statusText === 'OK') {
          this.showSuccess('Successfully sent feedback!');
          this.feedbackForm.reset();
          this.feedbackForm.setValue({ textControl: '', anonymityControl: false, publishControl: false })
          modal.close();
        }
        else {
          this.showError('An error occured.');
        }
      }, error: e => (console.log(e))
    })
    let fbsent = document.getElementById('fbsent')
    if (fbsent)
      fbsent.style.display = "block"
    player.play('feedbackGiven')
    this.text = '';
  }

  open(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' })
  }

  loopComplete(event: any) {
    player.pause('feedbackGiven')
    let fbsent = document.getElementById('fbsent')
    if (fbsent)
      fbsent.style.display = "none"
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }
}
