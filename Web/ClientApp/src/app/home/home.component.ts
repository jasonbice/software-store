import {Store} from "@ngrx/store";
import {AppState} from "../state/app.state";
import {Component} from "@angular/core";
import {selectSoftwareItems} from "../state/software/software.selectors";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  softwareItems$ = this.store.select(selectSoftwareItems);

  constructor(private store: Store<AppState>) {
  }

}
