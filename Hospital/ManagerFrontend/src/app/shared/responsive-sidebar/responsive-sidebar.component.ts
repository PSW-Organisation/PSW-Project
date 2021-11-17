import { Component, Input, ViewChild } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SidenavService } from './sidenav.service';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-responsive-sidebar',
  templateUrl: './responsive-sidebar.component.html',
  styleUrls: ['./responsive-sidebar.component.css']
})
export class ResponsiveSidebarComponent {

  @ViewChild('sidenav') public sidenav!: MatSidenav;
  isHandset$: Observable<boolean> = this._breakpointObserver.observe(Breakpoints.Handset)
  .pipe(
    map(result => result.matches),
    shareReplay()
  );
  @Input() sidenavTitle: string = "";
  isShowing: boolean = false;

  constructor(private _breakpointObserver: BreakpointObserver,
              private _sidenavService: SidenavService) { }

  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
  }

  open(): void {
    this.isShowing = true;
  }

  close(): void {
    this.isShowing = false;
  }

  toogle(): void {
    this.isShowing = !this.isShowing;
  }

}
