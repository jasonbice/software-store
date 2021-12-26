import {createFeatureSelector} from "@ngrx/store";
import {Software} from "../../shared/models/software.model";

export const selectSoftwareItems = createFeatureSelector<ReadonlyArray<Software>>('softwareItems');
