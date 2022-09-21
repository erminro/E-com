import Button from '@mui/material/Button';
import styled from 'styled-components';
// Types
import { CartItemType } from '../App';
// Styles


type Props = {
  item: CartItemType;
  addToCart: (clickedItem: CartItemType) => void;
  removeFromCart: (id: string) => void;
};
const Wrapper = styled.div`
  margin-left:300px;
  border-radius: 20px;
  display: flex;
  font-family: "Open Sans",Helvetica,Arial,sans-serif;
  border-bottom: 1px solid lightblue;
  padding-bottom: 20px;
  background-color: white;
  height:200px;
  width:700px;
  div {
    
  }
  .information
  {
    display: flex;
    justify-content: space-between;
    width: 300px;
    margin-left:30px;
  }
  .buttons {
    display: flex;
    justify-content: space-between;
    width: 150px;
    margin-left:20px;
  }
  p{
    margin-left:0px;
  }
  h3{
    margin-left:20px;
  }
  img {
    width: 220px;
    height:200px;
    margin-left: 130px;
  }
`;

const CartItem: React.FC<Props> = ({ item, addToCart, removeFromCart }) => (
  <Wrapper>
    <div>
      <h3>{item.name}</h3>
      <div className='information'>
        <h4>Price: {item.price}Lei</h4>
        <h4>Total: ${(item.amount * item.price).toFixed(2)} Lei</h4>
      </div>
      <div className='buttons'>
        <Button
          size='small'
          disableElevation
          variant='contained'
          onClick={() => removeFromCart(item.id)}
        >
          -
        </Button>
        <p>{item.amount}</p>
        <Button
          size='small'
          disableElevation
          variant='contained'
          onClick={() => addToCart(item)}
        >
          +
        </Button>
      </div>
    </div>
    <img src={item.imagePath} alt={item.name} />
  </Wrapper>
);
export default CartItem;