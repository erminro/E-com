import React, { useState } from 'react';
import { Button } from './Button';
import { Link } from 'react-router-dom';
import './Navbar.css';
import { AddShoppingCartOutlined  } from '@mui/icons-material';
import Badge from '@mui/material/Badge';
import { CartItemType } from '../App';

type Props={
    items: CartItemType[];
}

const  Navbar:React.FC<Props>=({items})=> {
  const [click, setClick] = useState(false);
  const handleClick = () => setClick(!click);
  const getTotalItems = (items: CartItemType[]) =>
  items.reduce((ack: number, item) => ack + item.amount, 0);
 

  return (
    <>
      <nav className='navbar'>
        <Link to='/' className='navbar-logo' >
          E-com
          <i className='fab fa-firstdraft' />
        </Link>
        <div className='menu-icon' onClick={handleClick}>
          <i className={click ? 'fas fa-times' : 'fas fa-bars'} />
        </div>
        <ul className={click ? 'nav-menu active' : 'nav-menu'}>
          <li className='nav-item'>
            <Link to='/' className='nav-links' >
              Home
            </Link>
          </li>
          <li
            className='nav-item'

          >
            <Link
              to='/products'
              className='nav-links'
             
            >
             All Products <i className='fas fa-caret-down' />
            </Link>
            
          </li>
          <li className='nav-item'>
            <Link
              to='/cart'
              className='nav-links'

            >
 
      <Badge badgeContent={getTotalItems(items)} color='error'>
          <AddShoppingCartOutlined />
      </Badge>
      
            </Link> 
          </li>
          
          <li>
            <Link
              to='/signin'
              className='nav-links-mobile'
            >
              Sign in
            </Link>
          </li>

        </ul>
        <Button />
      </nav>
    </>
  );
}

export default Navbar;
