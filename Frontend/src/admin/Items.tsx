import Grid from "@mui/material/Grid";
import axios from "axios";
import { useEffect, useState } from "react";
import styled from "styled-components";
import Sidebar from "./SideBar";
import ViewItem from "./ViewItems";

const Container1 = styled.div`
    margin-left: 300px;
    margin-top:50px;
`;


export default function Items(){
    
    const[products,setProducts]=useState<any[]>([]);
    useEffect(()=>{
        axios.get('https://localhost:7104/api/Product').then(response=>{
          setProducts(response.data);
        })
      },[])
      

      return(
        <div>
        <Sidebar></Sidebar>
        <Container1>
        <Grid container spacing={1}columnSpacing={{ xs: 1, sm: 1, md: 1 }}>
        {products.map(item => (
          <Grid item key={item.id} >
            <ViewItem item={item}/>
          </Grid>
        ))}
      </Grid>
      </Container1>
 
      </div>
      );
}