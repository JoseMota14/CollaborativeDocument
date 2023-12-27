import styled from "styled-components";

// Styled components
export const EditorContainer = styled.div`
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 10px;
  width: 80vw;
  background: rgb(63, 94, 251);
  background: radial-gradient(
    circle,
    rgba(63, 94, 251, 1) 0%,
    rgba(252, 70, 107, 1) 100%
  );
  width: 90vw;
  height: 80vh;
  justify-content: flex-start;
  display: inline-flex;
`;

export const H2 = styled.h2`
  width: 15%;
`;

export const DetailContainer = styled.div`
  display: flex;
  flex-direction: column;
`;

export const TextArea = styled.textarea`
  font-size: 16px;
  border: 4px solid #ccc;
  border-radius: 4px;
  resize: none;
  background-color: #000000;
  color: #f0ffff;

  /* Media Query for Small Screens (Mobile) */
  @media screen and (max-width: 576px) {
    width: 90vw;
    padding: 8px;
  }

  /* Media Query for Medium Screens (Tablets) */
  @media screen and (min-width: 577px) and (max-width: 992px) {
    width: 70vw;
    padding: 12px;
  }

  /* Media Query for Large Screens (Desktops) */
  @media screen and (min-width: 993px) {
    width: 70vw;
    padding: 15px;
  }
`;
