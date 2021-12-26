import {Software} from "../shared/models/software.model";

export interface AppState {

  softwareItems: ReadonlyArray<Software>;

}
