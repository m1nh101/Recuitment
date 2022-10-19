import { Moment } from "moment"
import client, { Response } from "./client"


export enum Status {
  BookedInterview = 4,
  CanceledApply = 5,
  WaitBookingInterview = 6
}

export interface CandidateViewType extends CandidateInRecruitmentProps
{ key: string }

export interface GeneralCandidateProps {
  id?: number
  name: string
  gender: number
  birthday: Moment
  email: string
  phone: string
  address: string
}

export interface CandidateInRecruitmentProps extends GeneralCandidateProps {
  status: Status
}

export interface CandidateRequestProps extends GeneralCandidateProps {
  qualification: string
  attachment: string
  gender: number
  note: string
}

export type CandidateResponse = CandidateRequestProps

export const postCandidateToRecruitment = async (recruitmentId: number, data: CandidateRequestProps): Promise<Response<CandidateResponse>> => {
  const response = await client.post(`/recruitments/${recruitmentId}/candidates`, data)
  return response.data
}

export const deleteCandidateFromRecruitment = async (recruitmentId: number, candidateId: number): Promise<boolean> => {
  const response = await client.delete(`/recruitments/${recruitmentId}/candidates/${candidateId}`)

  return response.status === 200
}

export const getCandidateDetailFromRecruitment = async (recruitmentId: number, candidateId: number): Promise<Response<CandidateResponse>> => {
  const response = await client.get(`/recruitments/${recruitmentId}/candidates/${candidateId}`)
  return response.data
}

export const updateCandidateFromRecruitment = async (recruitmentId: number, data: CandidateRequestProps): Promise<Response<CandidateResponse>> => {
  const response = await client.patch(`/recruitments/${recruitmentId}/candidates/${data.id}`, data)
  return response.data
}