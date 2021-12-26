import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {SoftwareSearchRequest} from "../models/software-search-request";
import {Software} from "../models/software.model";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class SoftwareService {

  // TODO: Move this to an .env file
  apiURL = 'http://localhost:5000';

  constructor(private httpClient: HttpClient) {
  }

  searchSoftware(searchRequest: SoftwareSearchRequest): Observable<Array<Software>> {
    let params = new HttpParams()
      .set('page', searchRequest?.page.toString())
      .set('pageSize', searchRequest.pageSize.toString())
      .set('sortBy', searchRequest.sortBy)
      .set('sortDescending', searchRequest.sortDescending ? 'true' : 'false')
      .set('minimumVersion', searchRequest.minimumVersion ?? '');

    return this.httpClient
      .get<{ pagedItems: Software[] }>(this.apiURL + '/software', {params})
      .pipe(map((softwareItems) => softwareItems.pagedItems || []));
  }

  handleError(error) {
    // TODO: Implement proper error handling (BugSnag, etc.)
    console.log(error);

    return throwError(error);
  }

}
