import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Form,
  FormGroup,
  FormText,
  Label,
  Button,
  Input,
  FormFeedback,
  Spinner,
} from "reactstrap";

export function Home() {
  const [url, setUrl] = useState("");
  const [errors, setErrors] = useState(false);
  const [available, setAvailable] = useState(true);
  const [invalid, setInvalid] = useState(false);
  const [disabled, setDisabled] = useState(false);
  const [spin, setSpin] = useState(false);

  const navigate = useNavigate();
  const handleInput = (event) => {
    setUrl(event.target.value);
  };

  const handleSubmit = async (url) => {
    console.log(url);
    await postSearchAsync(url);
  };

  const postSearchAsync = async (url) => {
    const response = await fetch("api/search", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ UrlWebsite: url.trim() }),
    });
    const data = await response.json();

    console.log(data);
    if (data.available) {
      setSpin(true);
      setTimeout(() => {
        setUrl(data.websiteUrl);
        setAvailable(true);
        setInvalid(false);
        setDisabled(false);
        setErrors(false);
        navigate("/frame", {
          state: {
            url: data.websiteUrl,
            date: data.timeStamp,
          },
        });
      }, 5500);
    } else if (data.errors) {
      setInvalid(true);
      setErrors(true);
      console.log(data.errors.UrlWebsite);
    } else {
      setUrl("");
      console.log("error");
      setAvailable(false);
      setInvalid(true);
      setErrors(false);
      console.log("not available");
    }
  };

  return (
    <div>
      <Form>
        <h1>Hi!</h1>
        <br />
        <FormGroup>
          <Label className="inputText">Please type in a proper URL:</Label>
          <Input
            onChange={handleInput}
            invalid={invalid}
            className="inputText"
            id=" web address"
            name=" web address"
            placeholder=" www.example.com"
            type="text"
            autoComplete="off"
          />

          {available ? (
            ""
          ) : (
            <FormFeedback>Oh no the website is not available!</FormFeedback>
          )}
          {errors ? (
            <FormFeedback>Please check the Url and try again!</FormFeedback>
          ) : (
            ""
          )}
          <br />
          <FormText id="formText" className="text">
            We'll search the oldest one!
          </FormText>
        </FormGroup>

        <Button
          onClick={() => handleSubmit(url)}
          disabled={disabled}
          className="center"
          size="lg"
          color="primary"
        >
          {spin ? (
            <div>
              <span> Loading ... </span>
              <Spinner size="lg">Loading...</Spinner>
            </div>
          ) : (
            <span> search</span>
          )}
        </Button>
      </Form>
    </div>
  );
}
