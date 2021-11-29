import { Injectable } from '@angular/core';
import { NgbDateAdapter, NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';


@Injectable()
export class CustomAdapter extends NgbDateAdapter<string> {

  readonly DELIMITER = '-';

  fromModel(value: string | null): NgbDateStruct | null {
    if (moment(value, 'DD-MM-YYYY', false).isValid()) {
      let date = value?.split(this.DELIMITER);
      if (date)
        return {
          day: parseInt(date[0], 10),
          month: parseInt(date[1], 10),
          year: parseInt(date[2], 10)
        };
    }
    return null;
  }

  toModel(date: NgbDateStruct | null): string | null {
    return date ? date.day + this.DELIMITER + date.month + this.DELIMITER + date.year : null;
  }
}

@Injectable()
export class CustomDateParserFormatter extends NgbDateParserFormatter {

  readonly DELIMITER = '.';

  parse(value: string): NgbDateStruct | null{
    if (value) {
      let date = value?.split(this.DELIMITER);
      return {
        day: parseInt(date[0], 10),
        month: parseInt(date[1], 10),
        year: parseInt(date[2], 10)
      };
    }
    return null;
  }

  format(date: NgbDateStruct | null): string {
    let dayPrefix = '';
    let monthPrefix = '';
    if(date && date.day < 10) dayPrefix = '0';
    if(date && date.month < 10) monthPrefix = '0';
    return date ? dayPrefix + date.day + this.DELIMITER + monthPrefix + date.month + this.DELIMITER + date.year + this.DELIMITER : '';
  }
}
