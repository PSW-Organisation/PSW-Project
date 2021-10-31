import { Component, OnInit, ɵNG_PROV_DEF } from '@angular/core';
import { ConfigService } from '../config/config.service';

@Component({
  selector: 'app-pecurka',
  templateUrl: './pecurka.component.html',
  styleUrls: ['./pecurka.component.css']
})
export class PecurkaComponent implements OnInit {
  pecurka?: string;

  constructor(private _pecurkaService: ConfigService) { }

  ngOnInit(): void {
  }

  getPecurka(): void {
    this._pecurkaService.getPecurka().subscribe(p => {
      this.pecurka = p;
      console.log(p);
    })
  }

}
