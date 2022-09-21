import CartItem from '../CartItem/CartItem';
import { CartItemType } from '../App';
import styled from 'styled-components';
import Navbar from '../Navbar/Navbar';

type Props = {
  cartItems: CartItemType[];
  addToCart: (clickedItem: CartItemType) => void;
  removeFromCart: (id: string) => void;
};
export const Wrapper = styled.aside`
  font-family: Arial, Helvetica, sans-serif;
  width: 1000px;
  padding: 20px;
  margin-left:300px;

`;
const H3=styled.h3`{
  margin-left:590px;
  font-family: Arial, Helvetica, sans-serif;
}`;
const H2=styled.h2`{
  margin-left:540px;
  font-family: Arial, Helvetica, sans-serif;
}`;
const P=styled.p`{
  margin-left:590px;
  font-family: Arial, Helvetica, sans-serif;
}`;
const Cart: React.FC<Props> = ({ cartItems, addToCart, removeFromCart }) => {
  const calculateTotal = (items: CartItemType[]) =>
    items.reduce((ack: number, item) => ack + item.amount * item.price, 0);

  return (
    <div>
    <Navbar items={cartItems}/>
    <Wrapper>
      <H2>Your Shopping Cart</H2>
      {cartItems.length === 0 ? <P>No items in cart.</P> : null}
      {cartItems.map(item => (
        <CartItem
          key={item.id}
          item={item}
          addToCart={addToCart}
          removeFromCart={removeFromCart}
        />
      ))}
      <H3>Total: ${calculateTotal(cartItems).toFixed(2)}</H3>
    </Wrapper>
    </div>
  );
}
export default Cart;