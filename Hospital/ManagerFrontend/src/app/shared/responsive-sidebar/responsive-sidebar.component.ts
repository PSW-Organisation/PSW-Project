import { Component, Input, ViewChild } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
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
  @Input() position: 'start' | 'end' = 'start';
  @Input() opened: boolean = false;

  constructor(private _breakpointObserver: BreakpointObserver) { }

  open(): void {
    this.sidenav.open();
  }

  close(): void {
    this.sidenav.close();
  }

  toogle(): void {
    this.sidenav.toggle();
  }

}
