import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { DepartmentProp } from "../apis/department";
import { LevelProps } from "../apis/level";
import { PositionProps } from "../apis/position";
import { RoleProps } from "../apis/role";
import { RootState } from "./store";

interface UtilProp {
  roles: Array<RoleProps>
  positions: Array<PositionProps>
  departments: Array<DepartmentProp>
  levels: Array<LevelProps>
}

const initialState: UtilProp = {
  roles: [],
  positions: [],
  departments: [],
  levels: []
}

const utilSlice = createSlice({
  name: 'utils',
  initialState,
  reducers: {
    appendRoles: (state, action: PayloadAction<Array<RoleProps>>) => {
      state.roles = [...state.roles, ...action.payload]
    },
    appendPositions: (state, action: PayloadAction<Array<PositionProps>>) => {
      state.positions = [...state.positions, ...action.payload]
    },
    appendDepartments: (state, action: PayloadAction<Array<DepartmentProp>>) => {
      state.departments = [...state.departments, ...action.payload]
    },
    appendLevels: (state, action: PayloadAction<Array<LevelProps>>) => {
      state.levels = [...state.levels, ...action.payload]
    }
  }
})

export const getRoles = (state: RootState) => state.utils.roles
export const getPositions = (state: RootState) => state.utils.positions
export const getLevel = (state: RootState) => state.utils.levels
export const getDepartments = (state: RootState) => state.utils.departments

export const {
  appendRoles,
  appendPositions,
  appendLevels,
  appendDepartments
} = utilSlice.actions

export default utilSlice.reducer