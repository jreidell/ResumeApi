import { Component } from '@angular/core';
import { Globals } from '../_models';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent {

  constructor(private globals: Globals) { }

}
