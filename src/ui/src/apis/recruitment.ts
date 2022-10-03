import { Moment } from "moment"
import { GeneralCandidateProps } from "./candidate"
import client, { Response } from "./client"

export interface GeneralRecruitmentProps{
  id?: number
  name: string
  startDate: Moment
  endDate: Moment
  salaryMin: number
  salaryMax: number
  experienceFrom: number
  experienceTo: number
  number: number
}

export type RecruitmentRequest = GeneralRecruitmentProps & {
  content: string
  benifit: string
  departmentId: number
  positionId: number
}

export interface RecruitmentDetailProps extends RecruitmentRequest {
  candidates: Array<GeneralCandidateProps>
}

type RecruitmentsResponse = Response<Array<GeneralRecruitmentProps>>
type RecruitmentDetailResponse = Response<RecruitmentDetailProps>

export const postRecruitment = async (data: RecruitmentRequest): Promise<Response<GeneralRecruitmentProps>> => {
  const response = await client.post('/recruitments', data)
  return response.data
}

export const patchRecruitment = async (id: string, data: RecruitmentRequest): Promise<Response<GeneralRecruitmentProps>> => {
  const response = await client.patch(`/recruitments/${id}`, data)
  return response.data
}

export const getRecruitments = async (): Promise<RecruitmentsResponse> => {
  const response = await client.get('/recruitments')
  return response.data
}

export const getRecruitmentDetail = async (id: string | number): Promise<RecruitmentDetailResponse> => {
  const response = await client.get(`/recruitments/${id}`)
  return response.data
}