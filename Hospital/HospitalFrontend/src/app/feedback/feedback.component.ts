import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../config/config.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { AnimationItem } from 'lottie-web';
import { AnimationOptions } from 'ngx-lottie';
import player from 'lottie-web';
import { Feedback } from './feedback';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  text: string = '';
  anonymous: boolean = false;
  publishAllowed: boolean = false;
  closeResult = '';
  feedbackForm = new FormGroup({
    text: new FormControl('')
  });

  constructor(private servise: ConfigService, private modalService: NgbModal, private toastr: ToastrService) { }

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
      id: 'f1',
      patientId: 'p1',
      text: this.feedbackForm.get("textControl")?.value,
      anonymous: this.feedbackForm.get("anonymityControl")?.value,
      publishAllowed: this.feedbackForm.get("publishControl")?.value,
    }
    this.servise.createFeedback(feedback).subscribe({
      next: c => {
        
        if (c){
          this.showSuccess('Successfully sent feedback!');
          this.feedbackForm.reset();
          this.feedbackForm.setValue({textControl: '', anonymityControl: false, publishControl: false})
          modal.close();
        }
        else{
          this.showError('An error occured.');
        }
      }
    })
    let fbsent = document.getElementById('fbsent')
    if (fbsent)
      fbsent.style.display = "block"
    player.play('feedbackGiven')
    this.text = '';
    this.anonymous = false;
    this.publishAllowed = false;
    //this.servise.g
  }

  open(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
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

  showError(message: string){
    this.toastr.error(message);
  }

  private getDismissReason(reason: any): string {
    this.text = '';
    this.anonymous = false;
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
