import { ArrowLeftOutlined } from "@ant-design/icons";
import { Button, Collapse, Typography } from "antd";
import { useForm } from "antd/es/form/Form";
import { Store } from "antd/lib/form/interface";
import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { v4 } from "uuid";
import { CandidateViewType } from "../../apis/candidate";
import { getRecruitmentDetail, patchRecruitment } from "../../apis/recruitment";
import { openSuccessNotification } from "../../App";
import { CandidateViewProp } from "../../helpers/candidates";
import { convertFormDataToObject, convertRecruitmentDetailValueToForm } from "../../helpers/recruitment";
import { selectRecruitment } from "../../store/recruitmentSlice";
import { AppDispatch } from "../../store/store";
import CandidateModal from "../Candidates/CandidateModal";
import ListCandidate from "../Candidates/ListCandidate";
import { RecruitmentFormValueProps } from "./NewRecruitment";
import RecruitmentForm from "./RecruitmentForm";

const { Title } = Typography
const { Panel } = Collapse

const RecruitmentDetail: React.FC = (): JSX.Element => {
  const [candidates, setCandidates] = useState<Array<CandidateViewType>>([])
  const [formValue, setFormValue] = useState<Store>({})
  const dispatch = useDispatch<AppDispatch>()
  const [modal, setModal] = useState<boolean>(false)
  const { id } = useParams()
  const [form] = useForm()
  const navigate = useNavigate()
  
  
  const openModal = () => {
    setModal(true)
  }

  const appendToCandidateList = (data: CandidateViewType): void => {
    // setCandidates([...candidates, data])
  }

  const removeCandidate = (id: number ): void => {
    const filterdCandidate = candidates.filter(e => e.id !== id)

    setCandidates(filterdCandidate)

    openSuccessNotification('Xoá thành công')
  }

  const handleSubmit = (value: RecruitmentFormValueProps): void => {
    const data = convertFormDataToObject(value)
    patchRecruitment(id!, data).then(res => {
      if(res.statusCode === 200){
        openSuccessNotification("Lưu thay đổi thành công")
      }
    })
  }

  useEffect(() => {
    getRecruitmentDetail(id!).then(res => {
      const sources = res.data!.candidates.map(item => {
        return {
          ...item, key: v4()
        }
      })

      console.log(sources)
      setCandidates(sources)
      setFormValue(convertRecruitmentDetailValueToForm(res.data!))
    })
    dispatch(selectRecruitment(id!))
  }, [id])

  return (
    <div className="p-1">
      <div className="ptb">
        <Button type="primary"
          onClick={() => navigate(-1)}>
          <ArrowLeftOutlined /> <span>Quay lại</span>
        </Button>
      </div>

      <Collapse>
        <Panel header={<Title level={5}>Thông tin tuyển dụng</Title>} key="1" showArrow={false}>
          <div style={{ backgroundColor: 'white', padding: '1rem', borderRadius: '7px' }}>
            <RecruitmentForm form={form} initialValues={formValue} onFinish={handleSubmit} />
            <div style={{ display: 'flex', justifyContent: 'end' }}>
              <Button onClick={() => {form.submit()}} type="primary">Lưu</Button>
            </div>
          </div>
        </Panel>
      </Collapse>
      <div style={{ marginTop: '1rem' }}>
        <Title level={3} style={{ textAlign: 'center', textTransform: 'uppercase', color: 'white' }}>Danh sách ứng viên</Title>
        <div className="flex-end ptb">
          <Button onClick={openModal} type="primary">Thêm ứng viên</Button>
          <CandidateModal
            visible={modal}
            changeVisible={setModal}
            appendTo={appendToCandidateList} />
        </div>
        <ListCandidate remove={removeCandidate} source={candidates}/>
      </div>
    </div>
  )
}

export default RecruitmentDetail;