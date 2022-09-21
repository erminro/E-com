import { Grid } from "@mui/material";
import styled from "styled-components";
import { CartItemType } from "../App";
import Item from "../Item/Item";
import Navbar from "../Navbar/Navbar";


type Props={
    cartItems: CartItemType[];
    products: any[];
    handleAddToCart: (clickedItem: CartItemType) => void;
    handleRemoveFromCart: (id: string) => void;
}
const Container = styled.div`
    margin-left: 100px;
    margin-top:50px;
`;
const Products: React.FC<Props> = ({ cartItems,products, handleAddToCart,handleRemoveFromCart }) =>{

    return(
      <div><Navbar items={cartItems}/>
        <Container>
        <Grid container spacing={1}columnSpacing={{ xs: 1, sm: 1, md: 1 }}>
        {products.map(item => (
          <Grid item key={item.id} >
            <Item item={item} handleAddToCart={handleAddToCart} />
          </Grid>
        ))}
      </Grid>
      </Container>
      </div>
        );
}
export default Products;
