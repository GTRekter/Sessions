import './index.css'
import globalazurelogo from './images/globalazure2021.png';
import cloudgenlogo from './images/cloudgen.png';
import { Container, Row, Col } from 'reactstrap';

function endsWith(x, y) {
  var result = x.lastIndexOf(y) === x.length - y.length;
  return 
}

function App() {
    return (
        <Container>
            <Row className="mt-5">
                <Col xs="6">
                    <div className="text-center">
                        <img src={globalazurelogo} className="img-fluid me-300" id="globalazure-logo" alt="Global Azure logo" />
                    </div>
                </Col>
                <Col xs="6">
                    <div className="text-center">
                        <img src={cloudgenlogo} className="img-fluid me-300" id="cloudgen-logo" alt="CloudGen logo" />
                    </div>
                </Col>
            </Row>
            <Row className="mt-5">
                <Col>
                    <div className="text-center text-white">
                        <h1>Welcome to Global Azure 2021</h1>
                        <p className="lead">How Azure DevOps can boost your organization's productivity</p>
                    </div>
                </Col>
            </Row>
        </Container>
    );
}

export default App;