import {Component} from '@angular/core';
import {SoftwareService} from "../../services/software.service";
import {Store} from "@ngrx/store";
import {AppState} from "../../../state/app.state";
import {SoftwareSearchRequest} from "../../models/software-search-request";
import {searchedSoftware} from "../../../state/software/software.actions";

@Component({
  selector: 'app-software-search',
  templateUrl: './software-search.component.html',
  styleUrls: ['./software-search.component.css']
})
export class SoftwareSearchComponent {

  // Ideally this regex would be updated such that n == n.0 == n.0.0
  semVerRegEx = /^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$/g;

  searchRequest: SoftwareSearchRequest = {
    page: 0,
    pageSize: 10,
    sortDescending: false,
    sortBy: 'name',
    minimumVersion: null,
  };

  constructor(private softwareService: SoftwareService, private store: Store<AppState>) {
  }

  searchSoftware() {
    this.softwareService
      .searchSoftware(this.searchRequest)
      .subscribe((softwareItems) => this.store.dispatch(searchedSoftware({softwareItems})));
  }
}
