import { Store } from "antd/es/form/interface";
import moment from "moment";
import { v4 } from "uuid";
import { GeneralRecruitmentProps, RecruitmentDetailProps, RecruitmentRequest } from "../apis/recruitment";
import { RecruitmentFormValueProps } from "../components/Recruitments/NewRecruitment";

export interface RecruitmentViewProps{
  key: number | string
  name: string
  startDate: string
  endDate: string
  salary: string
  experience: string
  number: number
  id: number
}

const displayExperience = (experienceFrom: number, experienceTo: number ): string => {
  if (experienceFrom === 0 && experienceTo === 0){
    return 'Không yêu cầu'
  }

  return `${experienceFrom} - ${experienceTo} năm`
}

export const convertGeneralRecruitmentDataToViewData = (source: GeneralRecruitmentProps): RecruitmentViewProps => {
  return {
    key: v4(),
    name: source.name,
    startDate: moment(source.startDate).format('DD/MM/YYYY'),
    endDate: moment(source.endDate).format('DD/MM/YYYY'),
    salary: `${source.salaryMin.toLocaleString('vi-VN', {
      style: 'currency',
      currency: 'VND'
    })} - ${source.salaryMax.toLocaleString('vi-VN', {
      style: 'currency',
      currency: 'VND'
    })}`,
    experience: displayExperience(source.experienceFrom, source.experienceTo),
    number: source.number,
    id: source.id ?? 0
  }
}

export const convertFormDataToObject = (id: number, source: RecruitmentFormValueProps): RecruitmentRequest => {
  return {
    id: id,
    name: source.name,
    content: source.content,
    benifit: source.benifit,
    number: source.quantity,
    startDate: source.times[0],
    endDate: source.times[1],
    experienceFrom: source.experience[0],
    experienceTo: source.experience[1],
    salaryMin: source.salary[0],
    salaryMax: source.salary[1],
    departmentId: source.department,
    positionId: source.position
  }
}

export const convertRecruitmentDetailValueToForm = (source: RecruitmentDetailProps): Store => {
  return {
    ['salary']: [source.salaryMin, source.salaryMax],
    ['experience']: [source.experienceFrom, source.experienceTo],
    ['times']: [moment(source.startDate), moment(source.endDate)],
    ['content']: source.content,
    ['benifit']: source.benifit,
    ['position']: source.positionId,
    ['department']: source.departmentId,
    ['name']: source.name,
    ['quantity']: source.number
  }
}