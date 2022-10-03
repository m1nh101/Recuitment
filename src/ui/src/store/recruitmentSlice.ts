import { createSlice, PayloadAction, Slice } from "@reduxjs/toolkit";
import { Store } from "antd/lib/form/interface";
import { CandidateViewProp } from "../helpers/candidates";
import { RecruitmentViewProps } from "../helpers/recruitment";
import { RootState } from "./store";

interface SelectedRecruitment {
  id: number
  candidates: Array<CandidateViewProp>
  detail: Store
}

interface RecruitmentState {
  sources: Array<RecruitmentViewProps>
  recruitmentSelected: SelectedRecruitment
}

const initialState: RecruitmentState = {
  sources: [],
  recruitmentSelected: {
    id: 0,
    candidates: [],
    detail: {}
  }
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
    selectRecruitment: (state, action: PayloadAction<SelectedRecruitment>) => {
      state.recruitmentSelected = action.payload
    },
    addCandidate: (state, action: PayloadAction<CandidateViewProp>) => {
      state.recruitmentSelected.candidates = [...state.recruitmentSelected.candidates, action.payload]
    },
    removeCandidate: (state, action: PayloadAction<number>) => {
      const index = state.recruitmentSelected.candidates.findIndex((e: CandidateViewProp) => e.id === action.payload)
      state.recruitmentSelected.candidates.splice(index, 1)
    }
  }
})

export const recruitmentSelector = (state: RootState) => state.recruitments.sources
export const selectedRecruitmentSelector = (state: RootState) => state.recruitments.recruitmentSelected

export const { loadRecruitment, addRecruitment, selectRecruitment, removeCandidate, addCandidate } = recruitmentSlice.actions

export default recruitmentSlice.reducer