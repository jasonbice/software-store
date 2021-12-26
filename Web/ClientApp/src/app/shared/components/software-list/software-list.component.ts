import {Component, Input} from '@angular/core';
import {Software} from "../../models/software.model";

@Component({
  selector: 'app-software-list',
  templateUrl: './software-list.component.html',
  styleUrls: ['./software-list.component.css']
})
export class SoftwareListComponent {

  @Input() softwareItems: ReadonlyArray<Software>;

}
