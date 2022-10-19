import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { EmployeeViewProps } from "../helpers/employee";
import { RootState } from "./store";

interface EmployeeState {
  sources: Array<EmployeeViewProps>
}

const initialState: EmployeeState = {
  sources: []
}

const employeeSlice = createSlice({
  name: 'employees',
  initialState,
  reducers: {
    appendEmployees: (state, action: PayloadAction<Array<EmployeeViewProps>>) => {
      state.sources = [...state.sources, ...action.payload]
    },
    appendEmployee: (state, action: PayloadAction<EmployeeViewProps>) => {
      state.sources = [...state.sources, action.payload]
    }
  }
})

export const getEmployees = (state: RootState) => state.employees.sources

export const {
  appendEmployee,
  appendEmployees
} = employeeSlice.actions

export default employeeSlice.reducer