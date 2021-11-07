import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-responsive-sidebar',
  templateUrl: './responsive-sidebar.component.html',
  styleUrls: ['./responsive-sidebar.component.css']
})
export class ResponsiveSidebarComponent implements OnInit {

  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;
  isShowing: boolean = false;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addEventListener('change', this._mobileQueryListener);
  }

  ngOnInit(): void {
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
