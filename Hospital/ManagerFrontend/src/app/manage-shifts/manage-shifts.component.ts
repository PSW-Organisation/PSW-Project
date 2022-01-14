import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IShift } from './shift';
import { ShiftService } from './shift.service';

@Component({
  selector: 'app-manage-shifts',
  templateUrl: './manage-shifts.component.html',
  styleUrls: ['./manage-shifts.component.css']
})
export class ManageShiftsComponent implements OnInit {

  title: string = 'Manage shifts'
  shifts!: IShift[];
  formOpened: boolean = false;
  myForm!: FormGroup;
  formAction! : 'create' | 'update';
  newShift: IShift = {
    id: 0,
    name: "",
    shiftOrder: 0,
    startTime: new Date(),
    endTime: new Date()
  }

  constructor(
    private _shiftService: ShiftService,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this._shiftService.getAllShifts().subscribe(shifts => {
      this.shifts = shifts;
    })
    this.myForm = this._formBuilder.group({
      name: ['', Validators.required],
      startHours: ['', Validators.required],
      startMinutes: ['', Validators.required],
      endHours: ['', Validators.required],
      endMinutes: ['', Validators.required]
    })
  }

  removeShift(shift: IShift): void {
    this._shiftService.deleteShift(shift.id).subscribe(deleteShift => {
      this._shiftService.getAllShifts().subscribe(shifts => {
        this.shifts = shifts;
      })
    })
  }

  updateShift(shift: IShift): void {
    this.formOpened = true;
    this.myForm.patchValue({
      'name': shift.name,
      'startHours': new Date(shift.startTime).getHours(),
      'startMinutes': new Date(shift.startTime).getMinutes(),
      'endHours': new Date(shift.endTime).getHours(),
      'endMinutes': new Date(shift.endTime).getMinutes(),
    });
    this.newShift.id = shift.id;
    this.formAction = 'update';
  }

  createShift(): void {
    this.formOpened = true;
    this.myForm.patchValue({
      'name': '',
      'startHours': null,
      'startMinutes': null,
      'endHours': null,
      'endMinutes': null,
    });
    this.newShift.id = 0;
    this.formAction = 'create'
  }

  submit(): void {
    this.newShift.name = this.myForm.controls.name.value;

    let startDate = new Date(Date.UTC(1, 1, 1, 0, 0, 0));
    startDate.setUTCHours(this.myForm.controls.startHours.value);
    startDate.setUTCMinutes(this.myForm.controls.startMinutes.value);
    this.newShift.startTime = startDate;

    let endDate = new Date(Date.UTC(1, 1, 1, 0, 0, 0));
    endDate.setUTCHours(this.myForm.controls.endHours.value);
    endDate.setUTCMinutes(this.myForm.controls.endMinutes.value);
    this.newShift.endTime = endDate;

    if (this.formAction === 'create') {
      this._shiftService.createShift(this.newShift).subscribe(createdShift => {
        console.log(createdShift);
        this.formClose();
      })
    } else if (this.formAction === 'update') {
      this._shiftService.updateShift(this.newShift).subscribe(updatedShift => {
        console.log(updatedShift);
        this.formClose();
      })
    }
  }

  cancel(): void {
    this.formClose();
  }

  formClose(): void {
    this.formOpened = false;
    this._shiftService.getAllShifts().subscribe(shifts => {
      this.shifts = shifts;
    })
  }

}
