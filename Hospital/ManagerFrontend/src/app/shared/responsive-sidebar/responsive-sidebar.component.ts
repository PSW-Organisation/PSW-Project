import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SidenavService } from './sidenav.service';

@Component({
  selector: 'app-responsive-sidebar',
  templateUrl: './responsive-sidebar.component.html',
  styleUrls: ['./responsive-sidebar.component.css']
})
export class ResponsiveSidebarComponent implements OnInit {

  @ViewChild('sidenav') public sidenav!: MatSidenav;
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;
  isShowing: boolean = false;

  constructor(changeDetectorRef: ChangeDetectorRef,
              media: MediaMatcher,
              private sidenavService: SidenavService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addEventListener('change', this._mobileQueryListener);
  }

  ngOnInit(): void {
  }
  
  ngAfterViewInit(): void {
    this.sidenavService.setSidenav(this.sidenav);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeEventListener('change', this._mobileQueryListener);
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
