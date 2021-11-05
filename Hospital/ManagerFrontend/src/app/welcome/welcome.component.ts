import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  constructor() { }

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

}