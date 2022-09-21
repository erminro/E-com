import {useState,useEffect} from'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
// Components
import Cart from './Cart/Cart';
import styled from 'styled-components';
import IconButton from '@mui/material/IconButton';
import axios from 'axios';
import Home from './Home';
import Products from './Products/Products';
import Admin from './admin/Admin';
import AddProducts from './admin/AddProducts';
import ItemsDelete from './admin/ItemsDelete';
import Items from './admin/Items';
import Signin from './Signin';
// Styles
export const Wrapper = styled.div`
  margin: 40px;
`;

export const StyledButton = styled(IconButton)`
  position: fixed;
  z-index: 100;
  right: 20px;
  top: 20px;
`
// Types
export type CartItemType = {
  id: string;
  name: string;
  companyName: string;
  description: string;
  price: number;
  imagePath: string;
  amount: number;
};



const App = () => {
  const cartFromLocalStorage=JSON.parse(localStorage.getItem('cart')||'{}')
  const[cartItems,setCartItems]=useState<CartItemType[]>(Object.keys(cartFromLocalStorage).length===0?[]:cartFromLocalStorage);
  useEffect(()=>{
    localStorage.setItem("cart",JSON.stringify(cartItems))
  },[cartItems])
  const[products,setProducts]=useState<any[]>([]);
  useEffect(()=>{
    axios.get('https://localhost:7104/api/Product').then(response=>{
      setProducts(response.data);
    })
  },[])


  const handleAddToCart = (clickedItem: CartItemType) => {
    setCartItems(prev => {
      const isItemInCart = prev.find(item => item.id === clickedItem.id);

      if (isItemInCart) {
        return prev.map(item =>
          item.id === clickedItem.id
            ? { ...item, amount: item.amount + 1 }
            : item
        );
      }
      return [...prev, { ...clickedItem, amount: 1 }];
    });
  };

   const handleRemoveFromCart = (id: string) => {
    setCartItems(prev =>
      prev.reduce((ack, item) => {
        if (item.id === id) {
          if (item.amount === 1) return ack;
          return [...ack, { ...item, amount: item.amount - 1 }];
        } else {
          return [...ack, item];
        }
      }, [] as CartItemType[])
    );
  };
  return (
    <div>
      <Router>
       
        <Routes>
          <Route path='/'  element={<Home cartItems={cartItems}/>}/>
          <Route path='/signin' element={<Signin cartItems={cartItems}/>}/>
          <Route path='/cart'  element={<Cart cartItems={cartItems} addToCart={handleAddToCart} removeFromCart={handleRemoveFromCart}/>} />
          <Route path='/products' element={<Products cartItems={cartItems} products={products} handleAddToCart={handleAddToCart} handleRemoveFromCart={handleRemoveFromCart}/>}/>
          <Route path='/admin' element={<Admin/>}/>
          <Route path='/addproducts' element={<AddProducts/>}/>
          <Route path='/deleteproducts' element={<ItemsDelete/>}/>
          <Route path='/updateproducts' element={<Items/>}/>  
        </Routes>
      </Router>
      

    </div>
  );
};



export default App;
