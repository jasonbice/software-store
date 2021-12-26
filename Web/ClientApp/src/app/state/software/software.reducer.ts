import {createReducer, on} from '@ngrx/store';

import {searchedSoftware} from './software.actions';
import {Software} from "../../shared/models/software.model";

export const initialState: ReadonlyArray<Software> = [];

export const softwareItemsReducer = createReducer(
  initialState,
  on(searchedSoftware, (state, {softwareItems}) => (softwareItems))
);
