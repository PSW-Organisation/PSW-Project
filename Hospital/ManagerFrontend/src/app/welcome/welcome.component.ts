import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/jwt/auth.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private toastr: ToastrService) { }

  public loadExternalScript(url: string) {
    const body = <HTMLDivElement>document.body; const script =
      document.createElement('script'); script.innerHTML = ''; script.src = url; script.async = true; script.defer = true;
    body.appendChild(script);
  } 
  
  ngOnInit() {
    this.loadExternalScript("https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js");
    this.loadExternalScript("https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js");
    this.loadExternalScript("../../assets/scripts/jquery-3.2.1.min.js");
    this.loadExternalScript("../../assets/scripts/all-plugins.js");
    this.loadExternalScript("../../assets/scripts/plugins-activate.js");
  }

  login() {
    this.authService.login(this.username, this.password).subscribe(response => {
      // this.profileService.getProfileData(this.username).subscribe((res: any) => {
      //   if (res.loginType === 0) {
      //     this.router.navigate(['/profile']);
      //   } else {
      //    this.showError('Incorrect username or password!')
      //   }
      // });
    });
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }

}