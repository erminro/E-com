import React from 'react';
import shop from "./shopp.jpeg";
import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';
import { CartItemType } from './App';
import Navbar from './Navbar/Navbar';
const IMG = styled.img`
  width: 100%;
  height:90%;
`;
const TXT=styled.h1`
  @import url('https://fonts.google.com/specimen/Rampart+One');
  position: absolute;
  top: 400px;
  right: 160px;
  color:#203647;
  font-family: Rampart+One,sans-serif;
`;
const Button=styled.button`
  position:absolute;
  bottom: 350px;
  right: 160px;
  width: 420px;
  height: 70px;
  display:flex;
  border-radius: 40px;
  padding: 8px 20px;
  font-size: 30px;
  color:#fff;
  border-color:#203647;
  background-color: #203647;
  align-items:center;
  justify-content: center;
  &:hover{
    padding: 6px 16px;
    transition: all 0.3s ease-out;
    background-color: var(--primary);
    color: #fff;
    border-radius: 40px;
    transition: all 0.3s ease-out;
  }
`;
type Props={
  cartItems: CartItemType[];
}
const Home: React.FC<Props> = ({ cartItems}) =>{
  let navigate = useNavigate(); 
  const routeChange = () =>{ 
  let path = '/products'; 
  navigate(path);
}
  return (
    <div>
      <Navbar items={cartItems}/>
      <TXT>NEWEST E-COMMERCE SITE</TXT>
      <Button onClick={routeChange}>Shop Now</Button>
      <IMG src={shop} alt="Shop"/> 
    </div>
  );
}
export default Home;
