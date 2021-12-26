import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {environment} from '../environments/environment';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {StoreDevtoolsModule} from '@ngrx/store-devtools';

import {StoreModule} from "@ngrx/store";
import {SoftwareListComponent} from "./shared/components/software-list/software-list.component";
import {SoftwareSearchComponent} from "./shared/components/software-search/software-search.component";
import {softwareItemsReducer} from "./state/software/software.reducer";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SoftwareListComponent,
    SoftwareSearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
    ], {relativeLinkResolution: 'legacy'}),
    StoreModule.forRoot({softwareItems: softwareItemsReducer}),
    StoreDevtoolsModule.instrument({
      maxAge: 25, // Retains last 25 states
      logOnly: environment.production, // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when the extension window is not open
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
