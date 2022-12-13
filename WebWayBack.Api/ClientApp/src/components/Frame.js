import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import Iframe from "react-iframe";
import { Button, Col, Row } from "reactstrap";

function Frame() {
  const navigate = useNavigate();
  const location = useLocation();

  const handleCloseButton = () => {
    navigate("/");
  };

  return (
    <div>
      <div className="dateText">
        <Row className=" dateText">
          <Col md={8}>
            <h2 className="">{location.state.date}</h2>
          </Col>
          <Col md={3}>
            <Button size="lg" color="primary" onClick={handleCloseButton}>
              X
            </Button>
          </Col>
        </Row>
      </div>
      <hr />
      <Iframe
        url={location.state.url}
        width="70%"
        height="70%"
        display="block"
        position="fixed"
      />
    </div>
  );
}

export default Frame;
