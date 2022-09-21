import styled from 'styled-components';
import shop from '../background.jpg'
import Sidebar from "./SideBar";
const IMG = styled.img`
  width: 100%;
  height:100%;
`;
export default function Admin(){
    return(
        <div>
            <Sidebar></Sidebar>
            <IMG src={shop} alt="Shop"/>
        </div>
    );
}