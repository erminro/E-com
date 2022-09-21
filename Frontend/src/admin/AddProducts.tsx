import React from 'react';
import { useState } from 'react';
import axios from 'axios';
import "./Users.css"
import Sidebar from './SideBar';
export default function AddProducts() {

    const [name, setName] = useState("");
    const [companyName, setcompanyName] = useState("");
    const [price, setprice] = useState("");
    const [message, setMessage] = useState("");
    const [description,setDescription]=useState("");
    const [imagePath,setImagePath]=useState("");
    const [image, setImage] = useState('');
    const [loading, setLoading] = useState(false);
    const uploadImage = async (e: { target: { files: any } }) => {
      const files = e.target.files
      const data = new FormData()
      data.append('file', files[0])
      data.append('upload_preset', 'internship')
      setLoading(true)
      const res = await fetch(
        'https://api.cloudinary.com/v1_1/dm196upxm/image/upload',
        {
          method: 'POST',
          body: data
        }
      )
      const file = await res.json()
  
      setImage(file.secure_url)
      setImagePath(file.secure_url);
      console.log(file.secure_url)
      setLoading(false)
    }
    let handleSubmit = async (e: { preventDefault: () => void; }) => {
      e.preventDefault();
      axios.post('https://localhost:7104/api/Product', {
        name: name,
        companyName: companyName,
        description: description,
        price: price,
        imagePath: imagePath,
      })
        .then((response) => {
        console.log(response);
        let res=response;
        if (res.status === 200) {
          setName("");
          setcompanyName("");
          setDescription("");
          setImage("");
          setImagePath("");
          setprice("");
          setMessage("Product created successfully");
        } else {
          setMessage("Some error occured");
        }
      });  
    } ;
  
    return (
      <div>
        <Sidebar></Sidebar>
        <div className='div_h1'>
          <h1>Add Product</h1>
        </div>
      <div className="Usr">
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            value={name}
            placeholder="Name"
            onChange={(e) => setName(e.target.value)}
          />
          <input
            type="text"
            value={companyName}
            placeholder="company name"
            onChange={(e) => setcompanyName(e.target.value)}
          />
          <input
            type="number"
            value={price}
            placeholder="Price"
            onChange={(e) => setprice(e.target.value)}
          />
          <input
            type="text"
            value={description}
            placeholder="Description"
            onChange={(e) => setDescription(e.target.value)}
          />
        <div>
        <input
          type="file"
          name="file"
          placeholder="Upload an image"
          onChange={uploadImage}
        />
        {loading ? (
          <h3>Loading...</h3>
        ) : (
          <img src={image} alt="" style={{ width: '300px' } } />
        )}
        </div>
          <button type="submit">Create</button>
  
          <div className="message">{message ? <p>{message}</p> : null}</div>
        </form>
      </div>
      </div>
    );
}
