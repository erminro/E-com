
  
  // Types
  import React, { useEffect, useState } from "react";
import axios from "axios";
import styled from "styled-components";
  // Styles
  const Container = styled.div`
  flex: 1;
  padding:10px;
  margin: 5px;
  display: flex;
  align-items:center;
  background-color: #ffffff;
  position: relative;
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  border-radius: 10px;
`;
const Container1 = styled.div`
flex: 1;
align-items:center;
`;
const FOrm=styled.form`
align-items:center;
text-align:center;
`;
  type Props = {
    item: any;
  }; 
  const ViewItem: React.FC<Props> = ({ item }) =>{       
    const [name, setName] = useState("");
    const [companyName, setcompanyName] = useState("");
    const [price, setprice] = useState("");
    const [message, setMessage] = useState("");
    const [description,setDescription]=useState("");
    const [imagePath,setImagePath]=useState("");
    const [image, setImage] = useState('');
    const [loading, setLoading] = useState(false);
    useEffect(()=>{setName(item.name)},[item.name])
    useEffect(()=>{setcompanyName(item.companyName)},[item.companyName])
    useEffect(()=>{setDescription(item.description)},[item.description])
    useEffect(()=>{setprice(item.price)},[item.price])
    useEffect(()=>{setImagePath(item.imagePath)},[item.imagePath])
    useEffect(()=>{setImage(item.imagePath)},[item.imagePath])

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
        axios.put('https://localhost:7104/api/Product', {
            id:item.id,
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
            setMessage("Product updated successfully");
          } else {
            setMessage("Some error occured");
          }
        });  
      } ;
    return(
    <Container>
      <Container1 className="Usr">
        <FOrm onSubmit={handleSubmit}>
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
          <button type="submit">Update</button><br></br>
          
          <div className="message">{message ? <p>{message}</p> : null}</div>
        </FOrm>
      </Container1>
    </Container>
  );
  }
  export default ViewItem;
  