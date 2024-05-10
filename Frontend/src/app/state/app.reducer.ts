import { ActionReducerMap,MetaReducer } from "@ngrx/store";

import { State } from "./app.state";
import * as EmployeeReducer from "./employee/employee.reducer";

export const reducers: ActionReducerMap<State> = {
  employees: EmployeeReducer.reducer,
};

export const metaReducers: MetaReducer<State>[] = [];
