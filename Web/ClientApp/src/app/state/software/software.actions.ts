import {createAction, props} from '@ngrx/store';
import {Software} from "../../shared/models/software.model";

export const searchedSoftware = createAction(
  'Search Software Success',
  props<{ softwareItems: ReadonlyArray<Software> }>()
);
