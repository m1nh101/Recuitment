import { ArrowLeftOutlined } from "@ant-design/icons";
import { Button, Collapse, Spin, Typography } from "antd";
import { useForm } from "antd/es/form/Form";
import { Store } from "antd/lib/form/interface";
import moment from "moment";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { getRecruitmentDetail, patchRecruitment, RecruitmentDetailProps } from "../../apis/recruitment";
import { convertFormDataToObject } from "../../helpers/recruitment";
import { selectedRecruitmentSelector } from "../../store/recruitmentSlice";
import CandidateModal from "../Candidates/CandidateModal";
import ListCandidate from "../Candidates/ListCandidate";
import { RecruitmentFormValueProps } from "./NewRecruitment";
import RecruitmentForm from "./RecruitmentForm";

const { Title } = Typography
const { Panel } = Collapse

const RecruitmentDetail: React.FC = (): JSX.Element => {
  const recruitment = useSelector(selectedRecruitmentSelector)
  const [modal, setModal] = useState<boolean>(false)
  const { id } = useParams()
  const [form] = useForm()
  const navigate = useNavigate()

  const openModal = () => {
    setModal(true)
  }

  const handleSubmit = (value: RecruitmentFormValueProps): void => {
    const data = convertFormDataToObject(value)
    patchRecruitment(recruitment.id, data).then(res => {
      if(res.statusCode === 200){
        alert("OK");
      }
    })
  }

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
            <RecruitmentForm form={form} initialValues={recruitment.detail} onFinish={handleSubmit} />
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
          <CandidateModal visible={modal} changeVisible={setModal} recruitmentId={recruitment.id}/>
        </div>
        <ListCandidate recruitment={id} source={recruitment.candidates}/>
      </div>
    </div>
  )
}

export default RecruitmentDetail;