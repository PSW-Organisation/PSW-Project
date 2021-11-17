import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveSidebarComponent } from './responsive-sidebar/responsive-sidebar.component';
import { MaterialModule } from './material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidenavService } from './responsive-sidebar/sidenav.service';

@NgModule({
  declarations: [
    ResponsiveSidebarComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    CommonModule,
    MaterialModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ResponsiveSidebarComponent,
  ],
  providers: [SidenavService]
})
export class SharedModule { }
