import { CartItemType } from "./App";
import Navbar from "./Navbar/Navbar";

type Props={
    cartItems: CartItemType[];
  }
const Signin: React.FC<Props> = ({ cartItems}) =>{
    return(
        <Navbar items={cartItems}></Navbar>
    );
}
export default Signin;