import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RoleProps } from "../apis/role";
import { DepartmentProps, LevelProps, PositionProps } from "../apis/util";
import { RootState } from "./store";

interface UtilProps {
  roles: Array<RoleProps>
  positions: Array<PositionProps>
  departments: Array<DepartmentProps>
  levels: Array<LevelProps>
}

const initialState: UtilProps = {
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
    appendDepartments: (state, action: PayloadAction<Array<DepartmentProps>>) => {
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