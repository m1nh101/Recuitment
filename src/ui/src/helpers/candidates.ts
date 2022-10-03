import moment from "moment"
import {CandidateResponse, GeneralCandidateProps } from "../apis/candidate"

export interface CandidateViewProp {
  id: number
  name: string
  email: string
  phone: string
  birthday: string
  gender: string
  address: string
}

export const convertCandidateToViewProp = (source: GeneralCandidateProps | CandidateResponse): CandidateViewProp => {
  return {
    name: source.name,
    address: source.address,
    birthday: moment(source.birthday).format("DD/MM/YYYY"),
    gender: source.gender == 0 ? "Nam" : "Nữ",
    email: source.email,
    phone: source.phone,
    id: source.id!
  }
}