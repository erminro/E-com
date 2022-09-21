
  import styled from "styled-components";
  
  import "../Item/ProductTemplate.css"
  // Types

  import React from "react";
import axios from "axios";
  // Styles
  
  type Props = {
    item: any;

  };
  
  
  const Image = styled.img`
  height: 220px;
  max-width:220px;
  z-index: 2;
  margin-top:10px;
  margin-bottom:50px;
  `;
  const Container = styled.div`
    flex: 1;
    margin: 5px;
    min-width: 220px;
    max-width:220px;
    height: 350px;
    display: flex;
    align-items:top;
    background-color: #ffffff;
    position: relative;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    border-radius: 10px;
  `;
  const Title=styled.h1`
  font-size: 14px;
  font-weight: 600;
  line-height: 1.428571429;
  font-family: "Open Sans",Helvetica,Arial,sans-serif;
  color: #222222;
  position:absolute;
  left:10px;
  top:220px;
  bottom:30px;
  max-width:200px;
  `;
  const Price=styled.h1`
  font-size: 0.9em;
  font-weight: 600;
  color: red;
  left:10px;    
  position:absolute;
  align-text:left;
  justify-content:left;  
  bottom:45px;
  `;
  const Button=styled.button`
    padding: 8px 20px;
    width: 220px;
    height: 30px;
    display:flex;
    position:absolute;
    border-radius: 10px;
    padding: 8px 20px;
    bottom:0px;
    color:#fff;
    background-color: #203647;
    align-items:center;
    justify-content: center;
    &:hover{
      padding: 6px 16px;
      transition: all 0.3s ease-out;
      background-color: var(--primary);
      color: #fff;
      border-radius: 10px;
      border: 2px solid #203647;
      transition: all 0.3s ease-out;
    }
  `;
  const Circle = styled.div`
    width: 200px;
    height: 100px;
    border-radius: 50%;
    background-color: white;
    position: absolute;
  `;
  
  const ItemDelete: React.FC<Props> = ({ item }) => {
    const deleteProduct=()=>{
        axios.delete('https://localhost:7104/api/Product/'+item.id)
        window.location.reload()
    };
    return(
        <div>
        <Container>
              <Circle />
              <Image src={item.imagePath} />
              <Title className="txts">
                  {item.name}
              </Title>
              <Price>
                  {item.price} Lei
              </Price>
              <Button onClick={deleteProduct}>
                  Delete
              </Button>
              
          </Container>
        </div>
  );}
  
  export default ItemDelete;