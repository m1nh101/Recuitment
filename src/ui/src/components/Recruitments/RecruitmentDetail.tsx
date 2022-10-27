import { ArrowLeftOutlined } from "@ant-design/icons";
import { Button, Collapse, Typography } from "antd";
import { useForm } from "antd/es/form/Form";
import { Store } from "antd/lib/form/interface";
import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { v4 } from "uuid";
import { ApplicationViewType, Status } from "../../apis/application";
import { getRecruitmentDetail, patchRecruitment } from "../../apis/recruitment";
import { openSuccessNotification } from "../../App";
import { convertFormDataToObject, convertRecruitmentDetailValueToForm } from "../../helpers/recruitment";
import { selectRecruitment } from "../../store/recruitmentSlice";
import { AppDispatch } from "../../store/store";
import CandidateModal from "../Application/ApplicationModal";
import ListCandidate from "../Application/ListApplication";
import { RecruitmentFormValueProps } from "./NewRecruitment";
import RecruitmentForm from "./RecruitmentForm";

const { Title } = Typography
const { Panel } = Collapse

const RecruitmentDetail: React.FC = (): JSX.Element => {
  const [candidates, setCandidates] = useState<Array<ApplicationViewType>>([])
  const [formValue, setFormValue] = useState<Store>({})
  const dispatch = useDispatch<AppDispatch>()
  const [modal, setModal] = useState<boolean>(false)
  const { id } = useParams()
  const [form] = useForm()
  const navigate = useNavigate()
  
  const openModal = () => {
    setModal(true)
  }

  const appendToCandidateList = (data: ApplicationViewType): void => {
    setCandidates([...candidates, data])
  }

  const updateStatus = (id: number, status: Status): void => {
    var index = candidates.findIndex(e => e.id == id);

    if(index != -1){
      candidates[index].status = status;
    }
  }

  const removeCandidate = (id: number ): void => {
    const filterdCandidate = candidates.filter(e => e.id !== id)

    setCandidates(filterdCandidate)

    openSuccessNotification('Xoá thành công')
  }

  const handleSubmit = (value: RecruitmentFormValueProps): void => {
    const data = convertFormDataToObject(parseInt(id!), value)
    console.log(data)
    patchRecruitment(id!, data).then(res => {
      if(res.statusCode === 200){
        openSuccessNotification("Lưu thay đổi thành công")
      }
    })
  }

  useEffect(() => {
    getRecruitmentDetail(id!).then(res => {
      const sources = res.data!.applications.map(item => {
        return {
          ...item, key: v4()
        }
      })
      console.log(res.data)
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
        <ListCandidate
          remove={removeCandidate}
          update={updateStatus}
          source={candidates}/>
      </div>
    </div>
  )
}

export default RecruitmentDetail;