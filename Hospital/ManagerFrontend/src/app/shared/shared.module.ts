import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveSidebarComponent } from './responsive-sidebar/responsive-sidebar.component';
import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [
    ResponsiveSidebarComponent,
    NavbarComponent
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
    NavbarComponent
  ]
})
export class SharedModule { }
