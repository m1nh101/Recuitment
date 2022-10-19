import { createSlice, PayloadAction, Slice } from "@reduxjs/toolkit";
import { RecruitmentViewProps } from "../helpers/recruitment";
import { RootState } from "./store";

interface RecruitmentState {
  sources: Array<RecruitmentViewProps>
  selectedRecruitment: number
}

const initialState: RecruitmentState = {
  sources: [],
  selectedRecruitment: 0
}
const recruitmentSlice: Slice = createSlice({
  name: 'recruitment',
  initialState,
  reducers: {
    loadRecruitment: (state, action: PayloadAction<Array<RecruitmentViewProps>>) => {
      state.sources = action.payload
    },
    addRecruitment: (state, action: PayloadAction<RecruitmentViewProps>) => {
      state.sources = [...state.sources, action.payload]
    },
    selectRecruitment: (state, action: PayloadAction<number>) => {
      state.selectedRecruitment = action.payload
    }
  }
})


export const recruitmentSelector = (state: RootState) => state.recruitments.sources

export const getCurrentRecruitment = (state: RootState) => state.recruitments.selectedRecruitment

export const {
  loadRecruitment,
  addRecruitment,
  selectRecruitment,
} = recruitmentSlice.actions

export default recruitmentSlice.reducer