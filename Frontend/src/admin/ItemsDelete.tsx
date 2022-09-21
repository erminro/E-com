import Grid from "@mui/material/Grid";
import axios from "axios";
import { useEffect, useState } from "react";
import styled from "styled-components";
import ItemDelete from "./ItemDelete";
import Sidebar from "./SideBar";
const Container1 = styled.div`
    margin-left: 300px;
    margin-top:50px;
`;

export default function ItemsDelete(){
    
    const[products,setProducts]=useState<any[]>([]);
    useEffect(()=>{
        axios.get('https://localhost:7104/api/Product').then(response=>{
          setProducts(response.data);
        })
      },[])
      

      return(
        <div>
        <Sidebar/>
        <Container1>
        <Grid container spacing={1}columnSpacing={{ xs: 1, sm: 1, md: 1 }}>
        {products.map(item => (
          <Grid item key={item.id} >
            <ItemDelete item={item}/>
          </Grid>
        ))}
      </Grid>
      </Container1>
 
      </div>
      );
}