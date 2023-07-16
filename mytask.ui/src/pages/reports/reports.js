import { Container } from "@mui/material";
import { useParams } from "react-router-dom";

const Reports = () => {
  const { id } = useParams();

  return <Container>Reports</Container>;
};

export default Reports;
