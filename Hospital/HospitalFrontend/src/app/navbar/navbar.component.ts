import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  username: string = 'imbiamba'

  constructor(public router: Router) { }

  ngOnInit(): void {
  }

  hyperLink(path : string) {
    this.router.navigate([path])
    console.log(path);
 }

}
